define ['todo-list/item'], (Item) ->
  'use strict'
  class Section
    constructor: (@title) ->
      @items = []
    add: (item) ->
      unless item instanceof Item
        throw 
          message: 'Trying to add non-Item item to a section'
      @items.push item
      @
    getData: () ->
      dataItems = (item.getData() for item in @items)
      title: @title
      items: dataItems
  Section