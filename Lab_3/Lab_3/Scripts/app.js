'use strict';
const CONTROLLER_DEFAULT_PATH = 'api/Students/';
var StudentList = [];

function addStudentHandler(formId, method) {
    $('#' + formId).submit(() => {
        event.preventDefault();
        var requestParams = {
            url: CONTROLLER_DEFAULT_PATH,
            type: method,
            data: $('#' + formId).serialize()
        };
        $.ajax(requestParams)
            .done((res) => {
                var sRes = 'Student ' + res.Name + ' successfuly added! Id #' + res.Id;
                showAlert("success", sRes);
            })
            .fail((jqXhr, textStatus, errorThrown) => {
                showAlert('danger', errorThrown);
            });
    });
}

function removeStudent(id) {
    var requestParams = {
        url: (CONTROLLER_DEFAULT_PATH + id),
        type: 'delete'
    };
    $.ajax(requestParams)
        .done((res) => {
            showAlert('info', 'Student ' + res.Name + ' deleted.');
            getAllStudents();
        })
        .fail((jqXhr, textStatus, errorThrown) => {
            showAlert('danger', errorThrown);
        });
}

function searchStudentsHandler(formId, method) {
    $('#' + formId).submit(() => {
        event.preventDefault();
        searchStudents(formId, method);
    });
}

function searchStudents(formId, method) {
    var requestParams = {
        url: CONTROLLER_DEFAULT_PATH + "search",
        type: method,
        data: $('#' + formId).serializeArray()
    };
    $.ajax(requestParams)
        .done((res) => {
            StudentList = res;
            updateStudentList(StudentList);
        })
        .fail((jqXhr, textStatus, errorThrown) => {
            showAlert('danger', errorThrown);
   });
}

function showAlert(type, text) {
    if (type == '' || type == undefined)
        type = 'info';
    $('#alert-text')
        .text(text);
    $('#alert')
        .toggleClass('alert-' + type);

    $('#alert').fadeIn().delay(3 * 1000).fadeOut();
}


function getAllStudents(method) {
    var requestParams = {
        url: CONTROLLER_DEFAULT_PATH + "getAll",
        type: 'GET'
    };
    $.ajax(requestParams)
        .done((res) => {
            StudentList = res;
            updateStudentList(StudentList);
        })
        .fail((jqXhr, textStatus, errorThrown) => {
            showAlert('danger', errorThrown);
        });
}

function updateStudentList(students) {
    $('#student-list > tbody').empty();
    for (var index in students) {
        var s = students[index];
        var rBtn = '<button onclick="removeStudent(' + s.Id + ')" class="btn btn-danger">Remove #' + s.Id + '</button>';
        var eBtn = '<button onclick="showEditModal(' + index + ')" class="btn btn-info">Edit</button>';
        var rLink = '<a href="'
            + s.Link.Href + '">student/'
            + s.Id + '</a>';
        var sRow = '<tr id="student-'
            + s.Id + '"><td>'
            + s.Id + '</td><td>'
            + s.Name + '</td><td>'
            + s.Phone + '</td><td>'
            + rBtn + ' ' + eBtn + '</td><td>'
            + rLink + '</td><tr>';
        $('#student-list > tbody').append(sRow);
    }
}

function updateStudent(sId) {
    var formId = 'update-form';
    var method = 'put';
    var requestParams = {
        url: CONTROLLER_DEFAULT_PATH + sId,
        type: method,
        data: $('#' + formId).serializeArray()
    };
    $.ajax(requestParams)
        .done((res) => {
            var sRes = 'Student successfuly updated!' + res.Id;
            showAlert("success", sRes);
            searchStudents('search', 'post');
        })
        .fail((jqXhr, textStatus, errorThrown) => {
            showAlert('danger', errorThrown);
            searchStudents('search', 'post');
        });
}

function showEditModal(studentIndex) {
    var student = StudentList[studentIndex];
    $('#update-id').text(student.Id);
    $('#update-form input[name="id"]').val(student.Id);
    $('#update-form input[name="name"]').val(student.Name);
    $('#update-form input[name="phone"]').val(student.Phone);
    $('#update-modal').modal('toggle');
    $('#update-form').submit(() => {
        event.preventDefault();
        updateStudent(student.Id);
        $('#update-modal').modal('toggle');
    });

}

function initForms() {
    addStudentHandler('add', 'post');
    searchStudentsHandler('search', 'post');
    // After first run
    getAllStudents();
}


(function () {
    initForms();
})();