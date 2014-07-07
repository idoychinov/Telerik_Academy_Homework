define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    Store = (function () {

        function typeCompare(item,compareOptions){
            if(item.getType() === compareOptions){
                return true;
            }
            return false;
        }

        function multyTypeCompare(item,compareOptions){
            var i,
                len,
                isOfType = false,
                itemType = item.getType();

            for(i=0, len = compareOptions.length; i<len; i++){
                if(itemType === compareOptions[i]){
                    isOfType = true;
                }
            }
            return isOfType;
        }

        function nameCompare(item,compareOptions){
            var itemName,
                partOfName;
            itemName = item.getName().toLowerCase();
            partOfName = compareOptions.toLowerCase();

            if(itemName.indexOf(partOfName)>-1){
                return true;
            }
            return false;
        }

        function priceCompare(item,compareOptions){
            var itemPrice,
                minPrice,
                maxPrice;
            itemPrice = item.getPrice();
            if(compareOptions) {
                minPrice = compareOptions.min || 0;
                if (compareOptions.max === undefined || compareOptions.max === null) {
                    maxPrice = Number.POSITIVE_INFINITY;
                } else {
                    maxPrice = compareOptions.max;
                }
            } else {
                minPrice=0;
                maxPrice=Number.POSITIVE_INFINITY;
            }

            if(minPrice>maxPrice){
                throw new TypeError('Min Price must be less then or equal to Max Price')
            }

            if(itemPrice>=minPrice && itemPrice<= maxPrice){
                return true;
            }
            return false;
        }

        function filter (comparer,compareOptions){
            var i,
                len,
                allItems,
                filteredItems =[];

            allItems= this;
            for(i=0, len=allItems.length; i<len; i++){
                if(comparer(allItems[i],compareOptions)){
                    filteredItems.push(allItems[i]);
                }
            }
            return filteredItems;
        }

        function sortByName(item1,item2){
            var first = item1.getName().toLowerCase(),
                second = item2.getName().toLowerCase();
            if(first<second){
                return -1;
            }
            if(first>second){
                return 1;
            }
            return 0;
        }

        function sortByPrice(item1,item2){
            var first = item1.getPrice(),
                second = item2.getPrice();
            return first - second;
        }

        function sort (sortFunction){
            var sortedItems;
            sortedItems = this.slice(0);
            return sortedItems.sort(sortFunction);
        }

        function Store() {
            this._itemsList =[];

        }

        Store.prototype.addItem = function (item) {
            if(!(item instanceof Item)) {
                throw new TypeError('Argument must be of type Item');
            }
            this._itemsList.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            return sort.call(this._itemsList,sortByName);
        };

        Store.prototype.getSmartPhones = function () {
            var FILTER = 'smart-phone';
            return sort.call(filter.call(this._itemsList,typeCompare,FILTER),sortByName);
        };

        Store.prototype.getMobiles = function () {
            var FILTER = ['smart-phone','tablet'];
            return sort.call(filter.call(this._itemsList,multyTypeCompare,FILTER),sortByName);
        };

        Store.prototype.getComputers = function () {
            var FILTER = ['pc','notebook'];
            return sort.call(filter.call(this._itemsList,multyTypeCompare,FILTER),sortByName);
        };

        Store.prototype.filterItemsByType = function (filterType) {
            return sort.call(filter.call(this._itemsList,typeCompare,filterType),sortByName);
        };

        Store.prototype.filterItemsByPrice = function (options) {
            return sort.call(filter.call(this._itemsList,priceCompare,options),sortByPrice);
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            return sort.call(filter.call(this._itemsList,nameCompare,partOfName),sortByName);
        };

        Store.prototype.countItemsByType = function () {
            var i,
                len,
                currentItemType,
                arr=[];
            for(i=0, len=this._itemsList.length; i<len; i++){
                currentItemType = this._itemsList[i].getType();
                if(arr[currentItemType]){
                    arr[currentItemType]+=1;
                } else{
                    arr[currentItemType]=1;
                }
            }
            return arr;
        };

        return Store;
    })();
    return Store;
});