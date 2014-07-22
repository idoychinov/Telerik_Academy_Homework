// Generated by CoffeeScript 1.7.1
(function() {
  define(['courses/student'], function(Student) {
    var Course;
    return Course = (function() {
      function Course(_title, _formula) {
        this._title = _title;
        this._formula = _formula;
        this._students = [];
      }

      Course.prototype.addStudent = function(student) {
        if (!(student instanceof Student)) {
          throw {
            message: 'Trying to add a non-Student object to a course'
          };
        }
        this._students.push(student);
        return this;
      };

      Course.prototype.calculateResults = function() {
        var student, _i, _len, _ref;
        this._totalScores = [];
        _ref = this._students;
        for (_i = 0, _len = _ref.length; _i < _len; _i++) {
          student = _ref[_i];
          this._totalScores.push({
            student: student,
            totalScore: this._formula(student)
          });
        }
        return this;
      };

      Course.prototype.getTopStudentsByExam = function(count) {
        var totalScores;
        if (count == null) {
          count = this.students.length;
        }
        totalScores = this._getSortedStudents(this._sortByExam);
        return totalScores.slice(0, count);
      };

      Course.prototype.getTopStudentsByTotalScore = function(count) {
        var totalScores;
        if (count == null) {
          count = this.students.length;
        }
        totalScores = this._getSortedStudents(this._sortByTotalScore);
        return totalScores.slice(0, count);
      };

      Course.prototype._getSortedStudents = function(sortBy) {
        var totalScores;
        if (!(sortBy && typeof sortBy === 'function')) {
          throw {
            message: 'sortBy must a function'
          };
        }
        if (!(this._totalScores && this._totalScores.length === this._students.length)) {
          this.calculateResults();
        }
        totalScores = this._totalScores.slice(0);
        totalScores.sort(sortBy);
        return totalScores.map(function(student) {
          var studentToReturn;
          return studentToReturn = {
            name: student.student.name,
            exam: student.student.exam,
            homework: student.student.homework,
            attendance: student.student.attendance,
            teamwork: student.student.teamwork,
            bonus: student.student.bonus,
            totalScore: student.totalScore
          };
        });
      };

      Course.prototype._sortByExam = function(st1, st2) {
        return st2.student.exam - st1.student.exam;
      };

      Course.prototype._sortByTotalScore = function(st1, st2) {
        return st2.totalScore - st1.totalScore;
      };

      return Course;

    })();
  });

}).call(this);

//# sourceMappingURL=course.map