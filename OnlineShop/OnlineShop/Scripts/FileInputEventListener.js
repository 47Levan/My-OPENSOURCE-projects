$(document).ready(function() {
    document.getElementById("fakeButton").addEventListener("click", function() {
        document.getElementById("realButton").addEventListener("change", function() {
            var reader = new FileReader();
            reader.onload=function(e) {
                $("#previewPicture").attr("src", e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        });
        document.getElementById("realButton").click();
    });

});
     