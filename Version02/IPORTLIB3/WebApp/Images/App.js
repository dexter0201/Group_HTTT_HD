$(function () {
	
	// set old data
	$("#btnUpload").click(function () {
		$("#OldAttachmentId").val($("#AttachmentId").val());
		$("#OldSrcImage").val($("#resultImage").attr("src"));
	});

	// upload file with choose file on PC
	$("#chooseDevice").change(function () {
		var file = $(this)[0].files[0];
		if (file !== null && file !== '') {
			var data = new FormData();
			data.append('file', file);
			$.ajax({
				contentType: "application/x-www-form-urlencoded, multipart/form-data",
				url: "/Attachment/Upload",
				processData: false, // tell jQuery not to process the data
				contentType: false, // tell jQuery not to set contentType
				type: "POST",
				data: data
			}).success(function (dataResponsive) {
				$("#ChoosedImage").attr("src", "/Uploads/" + dataResponsive.Url);
				$("#tmpAttachmentId").val(dataResponsive.AttachmentId);
				$("#txtUrl").attr("disabled", true);
				$("#chooseUrl").attr("disabled", true);
			});
		}
	});

	// click ok save image
	$("#readyImage").click(function () {
		if ($("#ChoosedImage").attr("src") !== "" && $("#tmpAttachmentId").val() !== "") {
			$("#AttachmentId").val($("#tmpAttachmentId").val());
			$("#resultImage").attr("src", $("#ChoosedImage").attr("src"));
		}
	});

	// cancel file upload
	$(".cancelImage").click(function () {
		$("#AttachmentId").val($("#OldAttachmentId").val());
		$("#resultImage").val($("#OldSrcImage").val());
	});

	// upload file from Url
	$("#chooseUrl").click(function () {
		var txtUrl = $("#txtUrl").val();
		if (txtUrl !== "") {
			var data = { Url: txtUrl };
			$.ajax({
				url: "/Attachment/UploadFromUrl",
				type: "POST",
				dataType: 'json',
				data: data
			}).success(function (dataResponsive) {
				$("#ChoosedImage").attr("src", "/Uploads/" + dataResponsive.Url);
				$("#tmpAttachmentId").val(dataResponsive.AttachmentId);
				$("#chooseDevice").attr("disabled", true);
			});
		}
	});

	// delete image
	$("#images .delete").click(function () {
		var _data = { AttachmentID: $(this).attr("value") };
		$.ajax({
			url: "/Attachment/DeleteAttachment",
			type: "POST",
			data: _data
		}).success(function (dataResponsive) {
			if (dataResponsive != -1) {
				$("#image_" + dataResponsive).remove();
			} else {
				alert("Delete error");
			}
		});
	});

	// generate barcode
	$("#btnGenerateBarcode").click(function () {
		var _data = 'data=' + $('#UserNo').val();
		$.ajax({
			url: '/Helper/GenerateBarcode',
			type: 'GET',
			data: _data
		}).success(function (data) {
			$("#barCodeResult").attr('src', '/Uploads/UsersBarcode/' + data);
		});
	});

    // Thong Ke Doc Gia
	var options = {
	    chart: {
	        renderTo: 'container',
	        type: 'column',

	    },
	    xAxis: {
	        categories: ["A", "B"]
	    },
	    title: {
	        text: '',
	    },
	    plotOptions: {
	        series: {
	            cursor: 'pointer',
	            point: {
	                events: {
	                    click: function (event) {
	                        var url = this.series.userOptions.URLs + this.category;
	                        location.href = url;
	                    }
	                }
	            }
	        }
	    },
	    series: [{
	        URLs: 'url',
	        name: 'Độc giả',
	        data: [
                800, 9
	        ]
	    }]
	};

	var optionsPie = {
	    chart: {
	        renderTo: 'container',
	        plotBackgroundColor: null,
	        plotBorderWidth: 1,//null,
	        plotShadow: false
	    },
	    title: {
	        text: 'Browser market shares at a specific website, 2014'
	    },
	    tooltip: {
	        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
	    },
	    plotOptions: {
	        pie: {
	            allowPointSelect: true,
	            cursor: 'pointer',
	            dataLabels: {
	                enabled: true,
	                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
	                style: {
	                    color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
	                }
	            }
	        }
	    },
	    series: [{
	        type: 'pie',
	        name: 'Percent',
	        data: [
                ['Firefox', 50],
                ['IE', 50]

	        ]
	    }]

	}

	$("#drawchart").submit(function (e) {
	
	    e.preventDefault();

	    var type = ($("#type").val());
	    if (type == "type1") {
	        var URL = "/Circulation/ReportUsersDepartmentsJSON";
	        $("#download").html("<a href='/Circulation/GetReportUsersDepartment/1'>PDF</a> |" +
                                "<a href='/Circulation/GetReportUsersDepartment/2'>WORD</a> |" +
                                "<a href='/Circulation/GetReportUsersDepartment/3'>EXCEL</a>");
	        $.getJSON(URL, null, function (data) {
	            options.title.text = ["Số lượng độc giả theo khoa"];
	            options.xAxis.categories = data.name;
	            options.series[0].data = data.value;
	            options.series[0].URLs = "#";
	            chart = new Highcharts.Chart(options);
	        });
	    }
	    else {
	        $("#download").html("");
	        $("#container").html("");
	        if (type == "type2") {
	            var URL = "/Circulation/ReportUsersLoanJSON";
	            $.getJSON(URL, null, function (data) {

	                options.title.text = ["Số lượng độc giả mượn sách theo năm"];
	                options.xAxis.categories = data.name;
	                options.series[0].data = data.value;
	                options.series[0].URLs = "GetReportUsersLoanByYear?year=";
	                chart = new Highcharts.Chart(options);
	            });
	        }
	        else {
	            if (type == "type3") {
	                var URL = "/Circulation/ReportLoansPercentJSON";
	                $.getJSON(URL, null, function (data) {
	                    optionsPie.title.text = ["Tỉ lệ mượn sách ở các sơ sở"];
	                    optionsPie.series[0].data = data;
	                    var chartPie = new Highcharts.Chart(optionsPie);
	                });
	            }
	            else {
	                if (type == "type4") {
	                    var url = "/Circulation/ReportOutOfDateLoans";
	                    $(location).attr('href', url);

	                }

	            }
	        }
	    }
	});

    $("#dialog-detail").dialog({
	    width: 700,
	    height: 500,
	    autoOpen: false,
	    modal: true,
	    title: "Chi tiết mượn sách",
	    buttons: {
	        Close: function () {
	            $("#dialog-detail").dialog('close');
	        }
	    }
	    });
        //detail loan
	    $("input.detail_loan").bind('click', function () {
	        $.ajax({
	            type: "POST",
	            url: "/Circulation/DetailLoan/" + $(this).val(),
	            contentType: "application/json; charset=utf-8",
	            success: function (data) {
	                $("#dialog-detail").html(data);
	                $("#dialog-detail").dialog("open");
	            }
	        });

	    
	});
});