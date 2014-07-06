define () ->
  'use strict'  
  class Item
    constructor: (@content) ->
    getData: () ->
      content: @content
  Item