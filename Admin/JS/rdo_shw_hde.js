
/* ---------------------------------Show Hide Text Box Of TouchScreen --------------------------------------- */
function Shw_Hide_TouchScreen_Txt() {
    var txtObj = document.getElementById('TxtTouchScreen');
    var rbgObj = document.getElementsByName('RdbTouchScreen');

    for (var i = 0; i < document.getElementsByName('RdbTouchScreen').length; i++) {
        var rbObj = document.getElementById('RdbTouchScreen_' + i)
        if (rbObj !== null) {
            if (rbObj.value == "2") {
                if (rbObj.checked == false) {
                    txtObj.style.display = "none";
                    break;
                }
                else {
                    txtObj.style.display = "";
                    break;
                }
            }
            else {
                txtObj.style.display = "inline";
                break;
                 }
            }
        }
    }



    /* ---------------------------------Show Hide Text Box Of Keypad --------------------------------------- */

    function Shw_Hide_Keypad_Txt() {
        var txtObj = document.getElementById('TxtKeypad');
        var rbgObj = document.getElementsByName('RdbKeypad');

        for (var i = 0; i < document.getElementsByName('RdbKeypad').length; i++) {
            var rbObj = document.getElementById('RdbKeypad_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }

    /* ---------------------------------Show Hide Text Box Of Java  --------------------------------------- */
    function Shw_Hide_Java_Txt() {
        var txtObj = document.getElementById('TxtJava');
        var rbgObj = document.getElementsByName('RdbJava');

        for (var i = 0; i < document.getElementsByName('RdbJava').length; i++) {
            var rbObj = document.getElementById('RdbJava_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }

    /* ---------------------------------Show Hide Text Box Of PrimaryCamera  --------------------------------------- */
    function Shw_Hide_PrimaryCamera_Txt() {
        var txtObj = document.getElementById('TxtPrimaryCamera');
        var rbgObj = document.getElementsByName('RdbPrimaryCamera');

        for (var i = 0; i < document.getElementsByName('RdbPrimaryCamera').length; i++) {
            var rbObj = document.getElementById('RdbPrimaryCamera_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of SecCamera  --------------------------------------- */
    function Shw_Hide_SecCamera_Txt() {
        var txtObj = document.getElementById('TxtSecondaryCamera');
        var rbgObj = document.getElementsByName('RdbSecCamera');

        for (var i = 0; i < document.getElementsByName('RdbSecCamera').length; i++) {
            var rbObj = document.getElementById('RdbSecCamera_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }



    /* ---------------------------------Show Hide Text Box Of VideoRecording  --------------------------------------- */
    function Shw_Hide_VideoRecording_Txt() {
        var txtObj = document.getElementById('TxtVideoRecording');
        var rbgObj = document.getElementsByName('RdbVideoRecording');

        for (var i = 0; i < document.getElementsByName('RdbVideoRecording').length; i++) {
            var rbObj = document.getElementById('RdbVideoRecording_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of GPRS  --------------------------------------- */
    function Shw_Hide_GPRS_Txt() {
        var txtObj = document.getElementById('TxtGPRS');
        var rbgObj = document.getElementsByName('RBGPRS');

        for (var i = 0; i < document.getElementsByName('RBGPRS').length; i++) {
            var rbObj = document.getElementById('RBGPRS_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of Edge  --------------------------------------- */
    function Shw_Hide_Edge_Txt() {
        var txtObj = document.getElementById('TxtEdge');
        var rbgObj = document.getElementsByName('RBEdge');

        for (var i = 0; i < document.getElementsByName('RBEdge').length; i++) {
            var rbObj = document.getElementById('RBEdge_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of 3G  --------------------------------------- */
    function Shw_Hide_RB3G_Txt() {
        var txtObj = document.getElementById('Txt3G');
        var rbgObj = document.getElementsByName('RB3G');

        for (var i = 0; i < document.getElementsByName('RB3G').length; i++) {
            var rbObj = document.getElementById('RB3G_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of Wifi  --------------------------------------- */
    function Shw_Hide_Wifi_Txt() {
        var txtObj = document.getElementById('TxtWifi');
        var rbgObj = document.getElementsByName('RBWifi');

        for (var i = 0; i < document.getElementsByName('RBWifi').length; i++) {
            var rbObj = document.getElementById('RBWifi_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of USB  --------------------------------------- */
    function Shw_Hide_USB_Txt() {
        var txtObj = document.getElementById('TxtUSBConectivity');
        var rbgObj = document.getElementsByName('RBUSB');

        for (var i = 0; i < document.getElementsByName('RBUSB').length; i++) {
            var rbObj = document.getElementById('RBUSB_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of GPSSupport  --------------------------------------- */
    function Shw_Hide_GPSSupport_Txt() {
        var txtObj = document.getElementById('TxtGPSSupport');
        var rbgObj = document.getElementsByName('RbGPSSupport');

        for (var i = 0; i < document.getElementsByName('RbGPSSupport').length; i++) {
            var rbObj = document.getElementById('RbGPSSupport_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of BlueTooth  --------------------------------------- */
    function Shw_Hide_BlueTooth_Txt() {
        var txtObj = document.getElementById('TxtBluetooth');
        var rbgObj = document.getElementsByName('RBBlueTooth');

        for (var i = 0; i < document.getElementsByName('RBBlueTooth').length; i++) {
            var rbObj = document.getElementById('RBBlueTooth_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of DLNA  --------------------------------------- */
    function Shw_Hide_DLNA_Txt() {
        var txtObj = document.getElementById('TxtDLNA');
        var rbgObj = document.getElementsByName('RBDLNA');

        for (var i = 0; i < document.getElementsByName('RBDLNA').length; i++) {
            var rbObj = document.getElementById('RBDLNA_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }



    /* ---------------------------------Show Hide Text Box Of WAP  --------------------------------------- */
    function Shw_Hide_WAP_Txt() {
        var txtObj = document.getElementById('TxtWAP');
        var rbgObj = document.getElementsByName('RBWAP');

        for (var i = 0; i < document.getElementsByName('RBWAP').length; i++) {
            var rbObj = document.getElementById('RBWAP_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }

    /* ---------------------------------Show Hide Text Box Of MusicPlayer  --------------------------------------- */
    function Shw_Hide_MusicPlayer_Txt() {
        var txtObj = document.getElementById('TxtMusicPlayer');
        var rbgObj = document.getElementsByName('RBMusicPlayer');

        for (var i = 0; i < document.getElementsByName('RBMusicPlayer').length; i++) {
            var rbObj = document.getElementById('RBMusicPlayer_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of VideoPlayer  --------------------------------------- */
    function Shw_Hide_VideoPlayer_Txt() {
        var txtObj = document.getElementById('TxtVideoPlayer');
        var rbgObj = document.getElementsByName('RBVideoPlayer');

        for (var i = 0; i < document.getElementsByName('RBVideoPlayer').length; i++) {
            var rbObj = document.getElementById('RBVideoPlayer_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }

    /* ---------------------------------Show Hide Text Box Of fm  --------------------------------------- */
    function Shw_Hide_fm_Txt() {
        var txtObj = document.getElementById('TxtFM');
        var rbgObj = document.getElementsByName('RBfm');

        for (var i = 0; i < document.getElementsByName('RBfm').length; i++) {
            var rbObj = document.getElementById('RBfm_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }

    /* ---------------------------------Show Hide Text Box Of CallMemory  --------------------------------------- */
    function Shw_Hide_CallMemory_Txt() {
        var txtObj = document.getElementById('TxtCallMemory');
        var rbgObj = document.getElementsByName('RBCallMemory');

        for (var i = 0; i < document.getElementsByName('RBCallMemory').length; i++) {
            var rbObj = document.getElementById('RBCallMemory_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of SMSMemory  --------------------------------------- */
    function Shw_Hide_SMSMemory_Txt() {
        var txtObj = document.getElementById('TxtSMSMemory');
        var rbgObj = document.getElementsByName('RBSMSMemory');

        for (var i = 0; i < document.getElementsByName('RBSMSMemory').length; i++) {
            var rbObj = document.getElementById('RBSMSMemory_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }


    /* ---------------------------------Show Hide Text Box Of PhonebookMemory  --------------------------------------- */
    function Shw_Hide_PhonebookMemory_Txt() {
        var txtObj = document.getElementById('TxtPhoneMemory');
        var rbgObj = document.getElementsByName('RBPhonebookMemory');

        for (var i = 0; i < document.getElementsByName('RBPhonebookMemory').length; i++) {
            var rbObj = document.getElementById('RBPhonebookMemory_' + i)
            if (rbObj !== null) {
                if (rbObj.value == "2") {
                    if (rbObj.checked == false) {
                        txtObj.style.display = "none";
                        break;
                    }
                    else {
                        txtObj.style.display = "";
                        break;
                    }
                }
                else {
                    txtObj.style.display = "inline";
                    break;
                }
            }
        }
    }