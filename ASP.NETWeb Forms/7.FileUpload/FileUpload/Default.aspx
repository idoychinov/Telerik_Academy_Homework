<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUpload.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
    <link href="styles/kendo.common.min.css" rel="stylesheet" />
    <link href="styles/kendo.default.min.css" rel="stylesheet" />
    <script src="scripts/jquery.min.js"></script>
    <script src="scripts/kendo.web.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <input name="uploaded" id="uploaded" type="file" runat="server" />

            <script>
                $(document).ready(function () {
                    $("#uploaded").kendoUpload({
                        async: {
                            saveUrl: "Upload.aspx",
                            autoUpload: true,
                        },
                        upload: onUpload
                    });
                });

                function onUpload(e) {
                    var files = e.files;
                    $.each(files, function () {
                        if (this.extension.toLowerCase() != ".zip") {
                            alert("Only .zip files can be uploaded");
                            e.preventDefault();
                        }
                    });
                }
            </script>
        </div>
    </form>
</body>
</html>
