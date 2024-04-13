$(document).ready(function () {
    listSuccess();
    $("#btnFilterList").click(ShowLoadingCog);

    $('.letter-filter').click(function () {
        var letter = $(this).data('letter');

        $.ajax({
            url: listURL,
            type: 'POST',
            data: {
                keyword: '',
                firstLetter: letter
            },
            success: function (data) {
                $('#film-list').html(data);
            }
        });
    });

    $(document).on("click", ".delete-film", function () {
        var filmId = $(this).closest("tr").data("film-id");
        var url = HideAppointmentURL.replace("__id__", filmId);
        $("#modalConfirmDeleteFilm").find(".btn-success").attr("href", url);
        $("#modalConfirmDeleteFilm").modal('show');
    });
});

function ShowLoadingCog() {
    $("#loadingCog").show();
}

function listSuccess() {
    RefreshPagerFunctions();
    checkInputStatus();
    $("#loadingCog").hide();

    $('#inp-keyword').keyup(function () {
        checkInputStatus();
    });
}

function checkInputStatus() {
    if ($('#inp-keyword').val() == '') {
        $('#btn-submitFilmFilter').html('Buscar');
    }
}