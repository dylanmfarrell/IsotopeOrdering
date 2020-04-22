function removeCollectionItem(el) {
    var $el = $(el);
    $el.parents($el.data('for')).remove();
}