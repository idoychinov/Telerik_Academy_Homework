function Object(){
    this.name = randNumber();
    this.age = randNumber();
    this.uniqueNumber= randString(35);
    this.otherNumber = randNumber(0,10000);
    this.newValue = randString(10);
    this.category=randNumber(0,1000);
    this.escalation=randNumber(0,50);
    this.state=randNumber(0,1);
    this.location=randString(15);
    this.reassignment_count=randNumber(0,100);
    this.time_worked=randString(10);
    this.order=randNumber(0,34);
    this.due_date=randString(10);
    this.number=randString(15);
    this.upon_approval=randString(10);
    this.sla_due=randString(20);
    this.follow_up=randString(10);
    this.notify=randNumber(0,1);
    this.business_stc=randNumber(0,5);
    this.caused_by=randString(10);
    this.rejection_goto=randString(5);
    this.assignment_group=randString(30);
    this.incident_state=randNumber(0,1);
    this.opened_at=randString(30);
    this.wf_activity=randString(10);
    this.calendar_duration=randString(15);
    this.group_list=randString(10);
    this.caller_id=randNumber(0,1);
    this.comments=randString(10);
    this.priority=randNumber(0,1);
    this.sys_id=randString(30);
    this.sys_updated_by=randString();
    this.variables=randString();
    this.delivery_task=randString();
    this.sys_updated_on=randString(20);
    this.parent=randString(10);
    this.active=randString();
    this.opened_by=randString(20);
    this.expected_start=randString();
    this.sys_meta=randString(6);
    this.watch_list=randString(15);
    this.company=randString(10);
    this.upon_reject=randString(8);
    this.work_notes=randString(15);
    this.sys_created_by=randString(15);
    this.cmdb_ci=randString(4);
    this.approval_set=randString(10);
    this.user_input=randString();
    this.sys_created_on=randString(18);
    this.contact_type=randString();
    this.rfc=randString(5);
    this.approval_history=randString(12);
    this.activity_due=randString();
    this.severity=randNumber(0,6);
    this.subcategory=randNumber(0,5);
    this.work_end=randNumber(0,12);
    this.closed_at=randString();
    this.close_notes=randString(15);
    this.variable_pool=randString(10);
    this.business_duration=randString(10);
    this.knowledge=randString();
    this.approval=randString(10);
    this.sys_mod_count=randNumber(0,100);
    this.problem_id=randNumber(0,2000);
    this.calendar_stc=randNumber(0,1);
    this.work_start=randString();
    this.sys_domain=randString(10);
    this.sys_response_variables=randString(10);
    this.correlation_id=randNumber(0,1000);
    this.sys_class_name=randString(10);
    this.short_description=randString(20);
    this.impact=randNumber(0,10);
    this.description=randString();
    this.correlation_display=randString(4);
    this.urgency=randNumber(0,10);
    this.assigned_to=randString(8);
    this.made_sla=randString(4);
    this.delivery_plan=randString(6);
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
        output="",
        i;
    if((typeof maxLength !== "number") || maxLength<4){
        maxLength=10;
    }

    length = randNumber(4,maxLength);

    for(i=0;i<maxLength;i++){
        output+=String.fromCharCode(randNumber(48,90));
    }
    return output;
}

var obj;
var encodedObj ={};
var arr = [];
var encodedArr =[];
var count;

for(var i =0; i<1000; i++){
    obj = new Object();
    arr.push(obj);
    count=0;

    for(var prop in obj){
        encodedObj[count]=obj[prop];
        count++;
    }
    encodedArr.push(encodedObj);
}

var fs = require('fs');

fs.writeFile("normalJSON.txt", JSON.stringify(arr), function(err) {
    if (err) {
        console.log(err);
    } else {
        console.log("The file was saved!");
    }
  })

fs.writeFile("encodedJSON.txt", JSON.stringify(encodedArr), function(err) {
    if (err) {
        console.log(err);
    } else {
        console.log("The file was saved!");
    }
})
/*
var str= JSON.stringify(arr);
console.log(str);
str= JSON.stringify(encodedArr);
console.log(encodedArr);
 */
