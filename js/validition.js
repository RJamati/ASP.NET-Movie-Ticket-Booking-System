
/************************************************************Image And Video validation***********************************/
function checkFileExtensionforimageandvideo(elem) {
    var filePath = elem.value;

    if (filePath.indexOf('.') == -1)
        return false;

    var validExtensions = new Array();
    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

    validExtensions[0] = 'jpg';
    validExtensions[1] = 'jpeg';
    validExtensions[2] = 'png';
    validExtensions[3] = 'gif';
    validExtensions[4] = 'mpeg';
    validExtensions[5] = 'mp4';
    validExtensions[6] = '3gp';
    validExtensions[7] = 'avi';
    validExtensions[8] = 'Flv';

    for (var i = 0; i < validExtensions.length; i++) {
        if (ext == validExtensions[i])
            return true;
    }

    alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');
    return false;
}
/************************************************************End*******************************************************/
/******************************************************Image  validation***********************************************/
function checkFileExtensionforimage(elem) {
    var filePath = elem.value;

    if (filePath.indexOf('.') == -1)
        return false;

    var validExtensions = new Array();
    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

    validExtensions[0] = 'jpg';
    validExtensions[1] = 'jpeg';
    validExtensions[2] = 'png';
    validExtensions[3] = 'gif';
    for (var i = 0; i < validExtensions.length; i++) {
        if (ext == validExtensions[i])
            return true;
    }

    alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');
    return false;
}
/************************************************************End*******************************************************/
/******************************************************Video  validation***********************************************/
function checkFileExtensionforvideo(elem) {
    var filePath = elem.value;

    if (filePath.indexOf('.') == -1)
        return false;

    var validExtensions = new Array();
    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

    validExtensions[1] = 'mpeg';
    validExtensions[2] = 'mp4';
    validExtensions[3] = '3gp';
    validExtensions[4] = 'avi';
    validExtensions[5] = 'Flv';

    for (var i = 0; i < validExtensions.length; i++) {
        if (ext == validExtensions[i])
            return true;
    }

    alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');
    return false;
}
/************************************************************End*******************************************************/
/******************************************************Only number*****************************************************/

function validatenumber(key) {
    //getting key code of pressed key
    var keycode = (key.which) ? key.which : key.keyCode;
    var phn = document.getElementById(key);
    //comparing pressed keycodes
    if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57))
    { return false; }
    else { return true; }
}
/************************************************************End*******************************************************/
/******************************************************Only alphanumeric***********************************************/
//Function to allow only alpha numeric to textbox
function validatealphanumeric(key) {
    var keycode = (key.which) ? key.which : key.keyCode
    var phn = document.getElementById(key);
    //comparing pressed keycodes
    if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57) && (keycode < 64 || keycode > 92) && (keycode < 97 || keycode > 122)) {
        return false;
    }
    else {
        return true;
    }
}
/************************************************************End*******************************************************/
/******************************************************Only Charcater***********************************************/
//Function to allow only alpha numeric to textbox
function validateChar(key) {
    var keycode = (key.which) ? key.which : key.keyCode
    var phn = document.getElementById(key);
    //comparing pressed keycodes
    if (!(keycode == 8 || keycode == 46) &&  (keycode < 64 || keycode > 92) && (keycode < 97 || keycode > 122)) {
        return false;
    }
    else {
        return true;
    }
}
/************************************************************End*******************************************************/
/******************************************************Email Validation***********************************************/

function EmailCheck(cc) {
    if (cc.value == '')
        return true;
    var rex = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/
    if (rex.test(cc.value)) {
        return true;
    }
    else {
        alert('Email field format is invalid.');
        cc.focus();
        cc.select();
        return false;
    }

}
/************************************************************End*******************************************************/
/******************************************************MobileNo Validation***********************************************/
function MobileNo(cc) {
    if (cc.value == '')
        return true;
    var rex = /^([23456789]{1})([0-9]{9})$/
    if (rex.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else {
        cc.style.color = "red";
        cc.focus();
        cc.select();
        return false;
    }

}
/************************************************************End*******************************************************/
/******************************************************Year Validation***********************************************/
function IsYear(cc) {
    if (cc.value == '')
        return true;
    var rex = /^([12]{1})([0-9]{3})$/
    if (rex.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else {
        cc.style.color = "red";
        cc.focus();
        cc.select();
        return false;
    }

}
/************************************************************End*******************************************************/
/******************************************************ispercentage Validation***********************************************/
function ispercentage(cc) {
    if (cc.value == '')
        return true;
    var rex = /^([0-9]{2})([.]{1})([0-9]{2})$/
    var rex1 = /^([0-9]{2})$/
    var rex2 = /^([0-9]{2})([.]{1})([0-9]{1})$/
    var rex3 = /^([0-9]{1})([.]{1})([0-9]{1})$/
    var rex4 = /^([0-9]{1})([.]{1})([0-9]{1})$/
    var rex5 = /^([0-9]{1})$/
    if (rex.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex1.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex2.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex3.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex4.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex5.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else {
        cc.style.color = "red";
        cc.focus();
        cc.select();
        return false;
    }

}
/************************************************************End*******************************************************/
/******************************************************IsNumber Validation***********************************************/
function IsNumber(cc) {
    if (cc.value == '')
        return true;
    var rex = /^[0-9][0-9]*(\.[0-9]*)?$/
    var rex1 = /^[0-9][0-9]*\,([0-9]*)?$/
    var rex2 = /^[0-9][0-9]*(\.[0-9]*)?$/
    if (rex.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex1.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex2.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else {
        cc.style.color = "red";
        cc.focus();
        cc.select();
        return false;
    }

}
/************************************************************End*******************************************************/
/******************************************************IsNumber Validation***********************************************/
function IsNumber1(cc) {
    if (cc.value == '')
        return true;
    var rex = /^[0-9][0-9]*(\.[0-9]*)?$/
    var rex1 = /^[0-9][0-9]*\,([0-9]*)?$/
    var rex2 = /^[0-9][0-9]*(\.[0-9]*)?$/
    if (rex.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex1.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else if (rex2.test(cc.value)) {
        return true;
        cc.style.color = "";
    }
    else {
        cc.focus();
        cc.select();
        cc.style.color = "red";
        return false;
    }

}
/************************************************************End*******************************************************/
/******************************************************enter Validation***********************************************/
function OnFocusInput(input) {
    input.style.color = "";
}