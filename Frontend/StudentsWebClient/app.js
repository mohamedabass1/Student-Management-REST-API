/* =========================================
   API CONFIGURATION
========================================= */

const API_BASE_URL = "http://localhost:5254/api/Students";

/* =========================================
   DOM ELEMENTS
========================================= */

const studentsTableBody = document.getElementById("studentsTableBody");
const loading = document.getElementById("loading");
const emptyState = document.getElementById("emptyState");
const alertBox = document.getElementById("alertBox");

const studentModal = document.getElementById("studentModal");
const modalTitle = document.getElementById("modalTitle");

const studentForm = document.getElementById("studentForm");

const studentIdInput = document.getElementById("studentId");
const studentNameInput = document.getElementById("studentName");
const studentAgeInput = document.getElementById("studentAge");
const studentGradeInput = document.getElementById("studentGrade");

const searchStudentIdInput = document.getElementById("searchStudentId");
const searchResult = document.getElementById("searchResult");

/* =========================================
   API FUNCTIONS
========================================= */

/**
 * Fetch all students
 */
async function getAllStudents() {
  const response = await fetch(`${API_BASE_URL}/All`);

  if (response.status === 404) {
    return [];
  }

  if (!response.ok) {
    throw new Error("Failed to fetch students.");
  }

  return await response.json();
}

/**
 * Get student by ID
 */
async function getStudentById(id) {
  const response = await fetch(`${API_BASE_URL}/${id}`);

  if (response.status === 404) {
    throw new Error("Student not found.");
  }

  if (response.status === 400) {
    throw new Error("Invalid student ID.");
  }

  if (!response.ok) {
    throw new Error("Failed to fetch student.");
  }

  return await response.json();
}

/**
 * Create new student
 */
async function createStudent(studentData) {
  const response = await fetch(API_BASE_URL, {
    method: "POST",

    headers: {
      "Content-Type": "application/json",
    },

    body: JSON.stringify(studentData),
  });

  if (response.status === 400) {
    throw new Error("Invalid student data.");
  }

  if (response.status === 500) {
    throw new Error("Server error while adding student.");
  }

  if (response.status !== 201) {
    throw new Error("Failed to create student.");
  }

  return await response.json();
}

/**
 * Update student
 */
async function updateStudent(id, studentData) {
  const response = await fetch(`${API_BASE_URL}/${id}`, {
    method: "PUT",

    headers: {
      "Content-Type": "application/json",
    },

    body: JSON.stringify(studentData),
  });

  if (response.status === 400) {
    throw new Error("Invalid student data.");
  }

  if (response.status === 404) {
    throw new Error("Student not found.");
  }

  if (response.status === 500) {
    throw new Error("Server error while updating.");
  }

  if (!response.ok) {
    throw new Error("Failed to update student.");
  }

  return await response.json();
}

/**
 * Delete student
 */
async function deleteStudent(id) {
  const response = await fetch(`${API_BASE_URL}/${id}`, {
    method: "DELETE",
  });

  if (response.status === 400) {
    throw new Error("Invalid student ID.");
  }

  if (response.status === 404) {
    throw new Error("Student not found.");
  }

  if (!response.ok) {
    throw new Error("Failed to delete student.");
  }

  return true;
}

/* =========================================
   UI FUNCTIONS
========================================= */

/**
 * Show alert messages
 */
function showAlert(message, type = "success") {
  alertBox.innerHTML = `
    <div class="alert alert-${type}">
      ${message}
    </div>
  `;

  setTimeout(() => {
    alertBox.innerHTML = "";
  }, 3000);
}

/**
 * Render students table
 */
function renderStudents(students) {
  studentsTableBody.innerHTML = "";

  if (students.length === 0) {
    emptyState.classList.remove("hidden");
    return;
  }

  emptyState.classList.add("hidden");

  students.forEach((student) => {
    const row = document.createElement("tr");

    row.innerHTML = `
      <td>${student.id}</td>
      <td>${student.name}</td>
      <td>${student.age}</td>
      <td>${student.grade}</td>

      <td>
        <div class="actions">

          <button
            class="btn btn-secondary"
            onclick="openEditModal(${student.id}, '${student.name}', ${student.age}, ${student.grade})"
          >
            Edit
          </button>

          <button
            class="btn btn-danger"
            onclick="handleDeleteStudent(${student.id})"
          >
            Delete
          </button>

        </div>
      </td>
    `;

    studentsTableBody.appendChild(row);
  });
}

/**
 * Load students from API
 */
async function loadStudents() {
  try {
    loading.classList.remove("hidden");

    const students = await getAllStudents();

    renderStudents(students);
  } catch (error) {
    showAlert(error.message, "error");
  } finally {
    loading.classList.add("hidden");
  }
}

/**
 * Open modal
 */
function openModal() {
  studentModal.classList.remove("hidden");
}

/**
 * Close modal
 */
function closeModal() {
  studentModal.classList.add("hidden");

  studentForm.reset();

  studentIdInput.value = "";
}

/**
 * Open add modal
 */
function openAddModal() {
  modalTitle.textContent = "Add Student";

  studentForm.reset();

  studentIdInput.value = "";

  openModal();
}

/**
 * Open edit modal
 */
function openEditModal(id, name, age, grade) {
  modalTitle.textContent = "Update Student";

  studentIdInput.value = id;
  studentNameInput.value = name;
  studentAgeInput.value = age;
  studentGradeInput.value = grade;

  openModal();
}

/* =========================================
   EVENT HANDLERS
========================================= */

/**
 * Submit form
 */
studentForm.addEventListener("submit", async (event) => {
  event.preventDefault();

  const id = studentIdInput.value;

  const studentData = {
    name: studentNameInput.value.trim(),
    age: Number(studentAgeInput.value),
    grade: Number(studentGradeInput.value),
  };

  try {
    // CREATE
    if (!id) {
      await createStudent(studentData);

      showAlert("Student added successfully.");
    }
    // UPDATE
    else {
      await updateStudent(id, studentData);

      showAlert("Student updated successfully.");
    }

    closeModal();

    await loadStudents();
  } catch (error) {
    showAlert(error.message, "error");
  }
});

/**
 * Delete student
 */
async function handleDeleteStudent(id) {
  const confirmed = confirm(
    `Are you sure you want to delete student with ID ${id}?`,
  );

  if (!confirmed) {
    return;
  }

  try {
    await deleteStudent(id);

    showAlert("Student deleted successfully.");

    await loadStudents();
  } catch (error) {
    showAlert(error.message, "error");
  }
}

/**
 * Search student
 */
document.getElementById("searchBtn").addEventListener("click", async () => {
  const id = Number(searchStudentIdInput.value);

  if (!id) {
    showAlert("Please enter a valid ID.", "error");
    return;
  }

  try {
    const student = await getStudentById(id);

    searchResult.innerHTML = `
      <div class="search-result-card">

        <h3>Student Details</h3>

        <p><strong>ID:</strong> ${student.id}</p>
        <p><strong>Name:</strong> ${student.name}</p>
        <p><strong>Age:</strong> ${student.age}</p>
        <p><strong>Grade:</strong> ${student.grade}</p>

      </div>
    `;
  } catch (error) {
    searchResult.innerHTML = "";

    showAlert(error.message, "error");
  }
});

/* =========================================
   BUTTON EVENTS
========================================= */

document
  .getElementById("openAddModalBtn")
  .addEventListener("click", openAddModal);

document.getElementById("closeModalBtn").addEventListener("click", closeModal);

document.getElementById("cancelBtn").addEventListener("click", closeModal);

document.getElementById("refreshBtn").addEventListener("click", loadStudents);

/* =========================================
   CLOSE MODAL WHEN CLICKING OUTSIDE
========================================= */

window.addEventListener("click", (event) => {
  if (event.target === studentModal) {
    closeModal();
  }
});

/* =========================================
   INITIAL LOAD
========================================= */

document.addEventListener("DOMContentLoaded", async () => {
  await loadStudents();
});
