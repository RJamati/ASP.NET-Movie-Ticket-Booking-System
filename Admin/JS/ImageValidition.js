function validate() {
    var uploadcontrol = document.getElementById('<%=FileUpload1.ClientID%>').value;
    //Regular Expression for fileupload control.
    var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.JPG|.jpeg|.JPEG|.gif|.GIF| .png|.PNG)$/;
    if (uploadcontrol.length > 0) {
        //Checks with the control value.
        if (reg.test(uploadcontrol)) {
            return true;
        }
        else {
            //If the condition not satisfied shows error message.
            alert("Only .jpg,.png,.gif,.jpeg files are allowed!");
            return false;
        }
    }
}