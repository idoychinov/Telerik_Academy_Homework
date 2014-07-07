define (['jquery','mustache'], function($,Mustache){
    var Controls;
    Controls = function(){
        function ComboBox(content){
            if(this instanceof ComboBox){
                if(content instanceof Array) {
                    this._content = content;
                }else {
                    throw {
                        message:'Content must be array.'
                    }
                }
            } else {
                return new ComboBox(content);
            }

        }

        function toggleComboBox(){
            var $this = $(this),
                $parentChildren = $this.parent().children('.combo-box-item');
            $parentChildren.removeClass('selected');
            $parentChildren.toggle();
            $this.addClass('selected');
            $this.show();
        }

        ComboBox.prototype.render = function(template){
            var renderedContent,
                $container,
                $result,
                data;

            data = {items :this._content};
            $container = $('<div />')
                .addClass('combo-box-container')
                .append('{{#items}}')
                .append(
                    $('<div />')
                        .hide()
                        .addClass('combo-box-item')
                        .append(template))
                .append('{{/items}}');
            renderedContent = Mustache.to_html($container[0].outerHTML,data);
            $result = $(renderedContent);
            $result.children('.combo-box-item').first().show().addClass('selected');
            $('body').on('click','.combo-box-container .combo-box-item',toggleComboBox);
            return $result[0].outerHTML;
        }
        return {
            ComboBox: ComboBox}
    }();
    return Controls;
});