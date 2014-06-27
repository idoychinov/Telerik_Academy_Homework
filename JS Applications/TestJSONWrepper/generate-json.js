function Object(){
    this.name = randNumber();
    this.age = randNumber();
}

function randNumber(min,max){
        var randomNumber;
        if((typeof min !== "number") || (typeof max !== "number") || (min>=max)){
            //throw "incorrect parameters for getRandom min: "+ min +"; max:"+max;
            min=1;
            max=100;
        }
        randomNumber = min + Math.floor(Math.random()*(max-min+1));
        return randomNumber;
}

function randString(maxLength){
    var length,
        string,
        i;
    if((typeof maxLength !== "number") || maxLength<4){
        maxLength=4;
    }
    length = randNumber(4,maxLength);

    //for(i)
}

var obj;
var arr = [];
for(var i =0; i<20; i++){
    obj = new Object();
    arr.push(obj);
}

//console.log(arr);
var str= JSON.stringify(arr)
console.log(str);