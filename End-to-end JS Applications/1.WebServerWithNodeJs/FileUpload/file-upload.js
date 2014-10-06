'user strict';

var PORT = 1234;
var FILES_DIRECTORY = './files';

var http = require('http');
var fs = require('fs');
var formidable = require('formidable');
var uuid = require('node-uuid');
var util = require('util');

var server = http.createServer(handleRequest).listen(PORT);
console.log('Server running at port:' +PORT);


function handleRequest(req,res){
    switch(req.url)
    {
        case '/' :
            res.writeHead(200,{
                'Content-Type': 'text/html'
            });
            res.write(generateUploadForm());
            res.end();
            break;
        case '/upload' :
            uploadFile(req,res);
            break;
    }

};

function generateUploadForm(){
    var form = '<form action="/upload" method="post"> <input type="file" size=80 name="files" enctype="multipart/form-data" multiple ><input type="submit" value="Upload"></form>'

    return form;
}

function uploadFile(req,res){
    if(req.method.toLocaleUpperCase() == "POST"){
        var uploadedFiles = [],
            form = new formidable.IncomingForm();

        form.uploadDir = FILES_DIRECTORY;
        form.multiples = true;
        form.keepExtensions = true;

        if (!fs.existsSync(FILES_DIRECTORY)) {
            fs.mkdirSync(FILES_DIRECTORY);
        }

        /* form.on('end', function(fields,files)
        {

        })

        form.on('fileBegin',function(name,file){

            var generatedId =  uuid.v4();
            var fileName = form.uploadDir +'/'+generatedId+ '.'+file.name;
            uploadedFiles.push(generatedId)
            file.path=fileName;
        });*/

        form.parse(req,function(err,fields,files){
            if(err){
                console.log(err);
            } else {
                res.writeHead(201,{
                    'Content-Type': 'text/html'
                });
                res.write("Files uploaded");
                res.end(util.inspect({fields: fields, files: files}));
            }
        })

    } else {
        res.writeHead(400,{
            'Content-Type': 'text/html'
        });
        res.write("Bad request");
        res.end();
    }
}