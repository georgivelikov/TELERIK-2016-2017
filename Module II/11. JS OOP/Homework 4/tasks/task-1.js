function solve() {
 
  var studentIdCounter = 0;
  var course;
 
  function validateTilte(titleName){
      if(titleName === undefined || titleName === null){
          throw new Error('Undefined or null course title name');
      }
      if(/\s{2,}/.test(titleName)){
          throw new Error('Title name has more than one empty space between words');
      }
      if(titleName.length < 1){
          throw new Error('Length of title name is less than 1');
      }
      if(titleName.length !== titleName.trim().length){
          throw new Error('Title name starts or ends with empty space');
      }
  }
 
  function validateStudentNameInput(name){
      if(!/^[A-Z][a-z]*\s[A-Z][a-z]*$/.test(name)){
          throw new Error('Invalid name input');
      }
  }
 
  class AcademyCourse{
      constructor(title, presentations){
          this.title = title;
          if(presentations.length < 1){
              throw new Error('Presentations array is empty');
          }
          this._presentations = presentations;
          this._students = [];
      }
 
      get title(){
          return this._title;
      }
      set title(newTitle){
          validateTilte(newTitle);
          this._title = newTitle;
      }
 
      get presentations(){
          return this._presentations;
      }
 
      get students(){
          return this._students;
      }
  }
 
  class Student{
      constructor(firstName, lastName){
          this._firstName = firstName;
          this._lastName = lastName;
          this._id = ++studentIdCounter;
          this._homeworks = [];
          this.finalScore = 0;
          this.examScore = 0;
      }
 
      get firstName(){
          return this._firstName;
      }
      get lastName(){
          return this._lastName;
      }
      get finalScore(){
          return this._finalScore;
      }
      set finalScore(fs){
          this._finalScore = fs;
      }
      get examScore(){
          return this._examScore;
      }
      set examScore(es){
          this._examScore = es;
      }
      get id(){
          return this._id;
      }
      get homeworks(){
          return this._homeworks;
      }
  }
 
  class Presentation {
      constructor(name) {
          this.name = name;
          this.homeworks = [];
      }
  }
 
    var Course = {
      init: function(title, presentations) {
        for(let i = 0; i < presentations.length; i += 1){
            validateTilte(presentations[i]);
        }
          course = new AcademyCourse(title, presentations);
          return this;
      },
      addStudent: function(name) {
          validateStudentNameInput(name);
          var nameArr = name.split(/\s/);
          var student = new Student(nameArr[0], nameArr[1]);
          course.students.push(student);
          return student.id;
      },
      getAllStudents: function() {
          var result = [];
          for(let i = 0; i < course.students.length; i += 1) {
              var current = course.students[i];
 
              var obj = {
                  firstname: current.firstName,
                  lastname: current.lastName,
                  id: current.id
              };
 
              result.push(obj);
          }
 
          return result;
      },
      submitHomework: function(studentID, homeworkID) {
          if(studentID == undefined || studentID === null || isNaN(studentID) || +studentID < 0 || +studentID > studentIdCounter){
              throw new Error('Invalid student id in submitHomework');
          }
          if(homeworkID == undefined || homeworkID === null || isNaN(homeworkID) || +homeworkID <= 0 || +homeworkID > course.presentations.length){
              throw new Error('Invalid student id in submitHomework');
          }
 
          var student = course.students.filter(s => s.id == studentID)[0];
          student.homeworks[homeworkID - 1] = true;
      },
      pushExamResults: function(results) {
          var set = new Set();
          if(!(results instanceof Array)){
              throw new Error();
          }
          for(let i = 0; i < results.length; i += 1){
              let currentObj = results[i];
 
              if(currentObj.StudentID === undefined || isNaN(currentObj.StudentID) ||
                  set.has(currentObj.StudentID) || currentObj.score === undefined){
                  throw new Error();
              }
 
              set.add(currentObj.StudentID);
              course.students[currentObj.StudentID - 1].examScore = currentObj.score;
          }
      },
      getTopStudents: function() {
          var topStudents = [];
          var result = [];
          var mapResults = new Map();
 
          for(let i = 0; i < studentIdCounter; i += 1){
              var currentStudent = course.students[i];
              var examScore = 0.75 * course.students[i].examScore;
              var countOfHomeworks = currentStudent.homeworks.filter(x => x === true).length;
              var homeworkScore = 0.25 * (countOfHomeworks / course.presentations.length);
              currentStudent.finalScore = examScore + homeworkScore;
          }
 
          function compare(a, b) {
              if (a.finalScore > b.finalScore){
                return -1;
              }
              if (a.finalScore < b.finalScore){
                return 1;
              }
 
              return 0;
          }
 
          var sortedStudents = course.students.map(x => JSON.parse(JSON.stringify(x)));
          sortedStudents.sort(compare);
 
          var len = studentIdCounter > 10 ? 10 : studentIdCounter;
          for(let i = 0; i < len; i += 1){
              result.push(sortedStudents[i]);
          }
          console.log(sortedStudents);
          return result;
      },
      getPresentation: function(name) {
          return new Presentation(name);
      }
    };
 
    return Course;
}
 
module.exports = solve;