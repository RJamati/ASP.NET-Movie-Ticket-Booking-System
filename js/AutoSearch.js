﻿
	    $(document).ready(function() {
	        SearchText();
	    });
	    function SearchText() {
	        $(".autosuggest").autocomplete({
	            source: function(request, response) {
	                $.ajax({
	                    type: "POST",
	                    contentType: "application/json; charset=utf-8",
	                    url: "Default.aspx/GetAutoCompleteData",
	                    data: "{'username':'" + document.getElementById('txtSearch').value + "'}",
	                    dataType: "json",
	                    success: function(data) {
	                        response(data.d);
	                    },
	                    error: function(result) {
	                        alert("Error");
	                    }
	                });
	            }
	        });
	    }
