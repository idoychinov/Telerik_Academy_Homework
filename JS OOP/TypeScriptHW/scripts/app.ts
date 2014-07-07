// cant reference the internal modules in other files for some reason so i've put them in one file

module Stores {
    'use strict';
    export interface IStore{
        addItem(item);
        getAll();
        getSmartPhones();
        getComputers();
        getMobiles();
        filterItemsByType(filterType);
        filterItemsByPrice(options);
        filterItemsByName(partOfName);
        countItemsByType();
    }

    export class Store implements IStore{
        private static  MIN_NAME_CHARACTERS = 6;
        private static MAX_NAME_CHARACTERS = 30;

        private _itemsList;
        private _name;

        public constructor(name:string) {
            this._itemsList = [];
            this._name = this.validateName(name);
        }

        private validateName(name:string):string {
            if ((typeof name !== 'string') || name.length < Store.MIN_NAME_CHARACTERS || name.length > Store.MAX_NAME_CHARACTERS) {
                throw new TypeError('Name must be a string with length between 6 and 30 characters');
            }
            return name;
        }

        public addItem(item) {
            if (!(item instanceof Item.Item)) {
                throw new TypeError('Argument must be of type Item');
            }
            this._itemsList.push(item);
            return this;
        }

        public getAll() {
            return sort.call(this._itemsList, sortByName);
        }

        public getSmartPhones() {
            var FILTER = 'smart-phone';
            return sort.call(filter.call(this._itemsList, typeCompare, FILTER), sortByName);
        }

        public getMobiles() {
            var FILTER = ['smart-phone', 'tablet'];
            return sort.call(filter.call(this._itemsList, multyTypeCompare, FILTER), sortByName);
        }

        public getComputers() {
            var FILTER = ['pc', 'notebook'];
            return sort.call(filter.call(this._itemsList, multyTypeCompare, FILTER), sortByName);
        }

        public filterItemsByType(filterType) {
            return sort.call(filter.call(this._itemsList, typeCompare, filterType), sortByName);
        }

        public filterItemsByPrice(options) {
            sort.call(filter.call(this._itemsList, priceCompare, options), sortByPrice);
        }

        public filterItemsByName(partOfName) {
            return sort.call(filter.call(this._itemsList, nameCompare, partOfName), sortByName);
        }

        public countItemsByType() {
            var i,
                len,
                currentItemType,
                arr = [];
            for (i = 0, len = this._itemsList.length; i < len; i++) {
                currentItemType = this._itemsList[i].getType();
                if (arr[currentItemType]) {
                    arr[currentItemType] += 1;
                } else {
                    arr[currentItemType] = 1;
                }
            }
            return arr;
        }
    }

    function sort(sortFunction) {
        var sortedItems;
        sortedItems = this.slice(0);
        return sortedItems.sort(sortFunction);
    }

    function typeCompare(item, compareOptions) {
        if (item.getType() === compareOptions) {
            return true;
        }
        return false;
    }

    function multyTypeCompare(item, compareOptions) {
        var i,
            len,
            isOfType = false,
            itemType = item.getType();

        for (i = 0, len = compareOptions.length; i < len; i++) {
            if (itemType === compareOptions[i]) {
                isOfType = true;
            }
        }
        return isOfType;
    }

    function nameCompare(item, compareOptions) {
        var itemName,
            partOfName;
        itemName = item.getName().toLowerCase();
        partOfName = compareOptions.toLowerCase();

        if (itemName.indexOf(partOfName) > -1) {
            return true;
        }
        return false;
    }

    function priceCompare(item, compareOptions) {
        var itemPrice,
            minPrice,
            maxPrice;
        itemPrice = item.getPrice();
        if (compareOptions) {
            minPrice = compareOptions.min || 0;
            if (compareOptions.max === undefined || compareOptions.max === null) {
                maxPrice = Number.POSITIVE_INFINITY;
            } else {
                maxPrice = compareOptions.max;
            }
        } else {
            minPrice = 0;
            maxPrice = Number.POSITIVE_INFINITY;
        }

        if (minPrice > maxPrice) {
            throw new TypeError('Min Price must be less then or equal to Max Price')
        }

        if (itemPrice >= minPrice && itemPrice <= maxPrice) {
            return true;
        }
        return false;
    }

    //there is some problem with filter by price function.

    function filter(comparer, compareOptions) {
        var i,
            len,
            allItems,
            filteredItems = [];

        allItems = this;
        for (i = 0, len = allItems.length; i < len; i++) {
            if (comparer(allItems[i], compareOptions)) {
                filteredItems.push(allItems[i]);
            }
        }
        return filteredItems;
    }

    function sortByName(item1, item2) {
        var first = item1.getName().toLowerCase(),
            second = item2.getName().toLowerCase();
        if (first < second) {
            return -1;
        }
        if (first > second) {
            return 1;
        }
        return 0;
    }

    function sortByPrice(item1, item2) {
        var first = item1.getPrice(),
            second = item2.getPrice();
        return first - second;
    }
}

module Item {
    'use strict';
    export interface IItem{
        getType():string;
        getName():string;
        getPrice():number;
    }

    export class Item implements IItem{
        private static ALLOWED_TYPES =[
            'accessory',
            'smart-phone',
            'notebook',
            'pc',
            'tablet'
        ];
        private static MIN_NAME_CHARACTERS = 6;
        private static MAX_NAME_CHARACTERS = 40;

        private _type : string;
        private _name : string;
        private _price : number;

        public constructor(type:string, name:string, price: number){
            this._type = this.validateType(type);
            this._name = this.validateName(name);
            this._price = this.validatePrice(price);

        }

        private validateType(type: string) : string {
            var isValidType : boolean,
                i: number;
            isValidType = false;

            for(i=0; i<Item.ALLOWED_TYPES.length; i++){
                if(type === Item.ALLOWED_TYPES[i]){
                    isValidType=true;
                }
            }
            if(!isValidType){
                throw new TypeError('Invalid item type')
            }
            return type;
        }

        private validateName(name: string) : string {
            if((typeof name !== 'string')|| name.length<Item.MIN_NAME_CHARACTERS || name.length>Item.MAX_NAME_CHARACTERS) {
                throw new TypeError('Name must be a string with length between 6 and 40 characters');
            }
            return name;
        }

        private validatePrice(price: number): number{
            if(isNaN(price)) {
                throw new TypeError('Price must be a decimal floating point number')
            }
            return price;
        }

        public getType() :string {
            return this._type;
        }

        public getName() :string {
            return this._name;
        }

        public getPrice() :number {
            return this._price;
        }
    }
}

module App {
    'use strict';
    var store;
    store = new Stores.Store('Telerik Academy Store');
    store = new Stores.Store('The Academy Store!');
    store.addItem(new Item.Item('accessory', 'Academy Headphones', 55.9))
        .addItem(new Item.Item('smart-phone', 'Academy Mobile', 888.9))
        .addItem(new Item.Item('notebook', 'Academy Note Enterprise', 2888.9))
        .addItem(new Item.Item('accessory', 'Speakers', 154.9))
        .addItem(new Item.Item('pc', 'The Academy', 999.9))
        .addItem(new Item.Item('notebook', 'Academy Note Light', 888.9))
        .addItem(new Item.Item('smart-phone', 'Academy Mobile+', 1588.9))
        .addItem(new Item.Item('tablet', 'Academy Mobile++', 1888.9))
        .addItem(new Item.Item('notebook', 'Academy Note Ultramate', 3999.9))
        .addItem(new Item.Item('pc', 'The Academy Enterprise', 1999.9))
        .addItem(new Item.Item('pc', 'The Academy Ultimate', 2999.9))
        .addItem(new Item.Item('tablet', 'The Academy Mobile ++--', 2888.8))
        .addItem(new Item.Item('smart-phone', 'Super Giga Mega Cool SmartPhone', 10.9))
        .addItem(new Item.Item('accessory', 'Useless accessory for your notebook', 99.9))
        .addItem(new Item.Item('pc', 'PC Kifla', 8999.9))
        .addItem(new Item.Item('notebook', 'Notebook Kifla', 9999.9))
        .addItem(new Item.Item('tablet', 'Tablet Kifla', 7999.9))
        .addItem(new Item.Item('smart-phone', 'iKifla', 16999.9))
        .addItem(new Item.Item('accessory', 'Kifla accessory #1', 299.9))
        .addItem(new Item.Item('accessory', 'Kifla accessory #2', 699.9))
        .addItem(new Item.Item('accessory', 'Kifla accessory #3', 199.9))
        .addItem(new Item.Item('accessory', 'Kifla accessory #4', 299.9))
        .addItem(new Item.Item('accessory', 'Kifla accessory #5', 399.9))
        .addItem(new Item.Item('accessory', 'Kifla accessory #6', 299.9))
        .addItem(new Item.Item('accessory', 'Kifla accessory #7', 799.9));

    /* returns all items */
    console.log(store.getAll());

    /*  returns 4 items (type = 'smart-phone') */
    console.log(store.getSmartPhones());

    /* returns 7 items (type = 'smart-phone' or 'tablet' */
    console.log(store.getMobiles());

    /* returns 8 items (type = 'pc' or 'notebook' */
    console.log(store.getComputers());

    /* returns all items, sorted ascending by price */
    console.log(store.filterItemsByPrice());

    /* returns only the items with price greater than 999.0, sorted ascending by price */
    console.log(store.filterItemsByPrice({
        min: 999
    }));

    /* returns only the items with price lesser than 3999.0, sorted ascending by price */
    console.log(store.filterItemsByPrice({
        max: 3999
    }));

    /* returns only the items with price greater than 999 and lesser than 3999.0 , sorted ascending by price */
    console.log(store.filterItemsByPrice({
        min: 999,
        max: 3999
    }));

    /* returns 10 items (type = 'accessory' */
    console.log(store.filterItemsByType('accessory'));

    /* returns 5 items, that have the word 'note' in their name. The search is case-insensitive */
    console.log(store.filterItemsByName('note'));

    /* returns an associative array. The value of each key is one of the types, and the value is the number of items with the type */
    console.log(store.countItemsByType());
}