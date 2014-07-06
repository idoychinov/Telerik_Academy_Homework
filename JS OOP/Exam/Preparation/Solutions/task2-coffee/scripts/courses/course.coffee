define ['courses/student'], (Student) ->
	class Course
		constructor: (@_title,@_formula) ->
			@_students = []
		addStudent: (student) ->
			unless student instanceof Student
				throw 
					message: 'Trying to add a non-Student object to a course'
			@_students.push student
			@
		calculateResults: () ->
			@_totalScores = []
			for student in @_students
				@_totalScores.push
					student: student
					totalScore: @_formula student
			@
		getTopStudentsByExam: (count = @students.length)->
			totalScores = @_getSortedStudents @_sortByExam
			totalScores[...count]
		getTopStudentsByTotalScore: (count = @students.length)->
			totalScores = @_getSortedStudents @_sortByTotalScore
			totalScores[...count]
		_getSortedStudents: (sortBy) ->
			unless sortBy  && typeof sortBy is 'function'
				throw
					message: 'sortBy must a function'
			unless @_totalScores and @_totalScores.length is @_students.length
				@calculateResults()
			totalScores = @_totalScores[..]
			totalScores.sort sortBy			
			totalScores.map (student) ->
				studentToReturn = 
					name: student.student.name
					exam: student.student.exam
					homework: student.student.homework
					attendance: student.student.attendance
					teamwork: student.student.teamwork
					bonus: student.student.bonus
					totalScore: student.totalScore								
		_sortByExam: (st1, st2) ->
			st2.student.exam - st1.student.exam
		_sortByTotalScore: (st1, st2) ->
			st2.totalScore - st1.totalScore
