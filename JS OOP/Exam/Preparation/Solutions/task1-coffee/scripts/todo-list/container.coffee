define ['todo-list/section'], (Section) ->
	'use strict'
	class Container
		constructor: () ->
			@sections = []
		add: (section) ->
			unless section instanceof Section
				throw 
					message: 'Trying to add non-Section object to Container'
			@sections.push section
			@
		getData: () ->
			dataSections = (section.getData() for section in @sections)
	Container