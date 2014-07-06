define () ->
	class Student
		constructor: (params) ->
			{@name, @exam, @homework, @attendance, @teamwork, @bonus} = params