var filme;
var listFilmesForCampeonato = [];



$(document).ready(function () {
    $('input[type=checkbox]').on('change', function () {
        //quantidade de selecionados
        var qt = $('input[type=checkbox]:checked').length;
        if (qt < 9) {
            filme = JSON.parse($(this).val())
            if ($(this).is(":checked")) {
                pushFilmeForCampeonato(filme);
            }
            else {
                removeFilmeForCampeonato(filme);
            }
            //coloca o atributo para ocultar qdo for 0
            $('#total').attr('data-value', qt);
            //coloca o resultado na div contador
            $('#total').text(qt + (qt > 0 ? ' ' : ' '));
        } else {
            swal("Atenção", "Selecione apenas 8 filmes.", "warning");
            $(this).prop("checked", false);
        }
    });
});



function redirect(campeao, vicecampeao) {
    var url = "/Home/ResultadoFinal/?campeao=" + campeao + "&vicecampeao=" + vicecampeao;
    window.location.href = url;
}

// Adiciona elemtno ao array 
function pushFilmeForCampeonato(data) {
    listFilmesForCampeonato.push(data);
    console.log(listFilmesForCampeonato);
}

// Remove elemeto do array
function removeFilmeForCampeonato(data) {
    $(listFilmesForCampeonato).each(function (i, value) {
        if (value.id == data.id) {
            listFilmesForCampeonato.splice(i, 1);
        }
    });
}

function gerarCampeonato() {
    if (listFilmesForCampeonato.length != 8) {
        swal("Atenção", "Selecione 8 filmes para gerar o campeonato.", "warning");
        return;
    }
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: "POST",
        url: "/Campeonato/Gerar",
        data: JSON.stringify(listFilmesForCampeonato),
        success: function (resultadoCampeonato) {
 
            redirect(resultadoCampeonato.filmeCampeao.titulo, resultadoCampeonato.filmeViceCampeao.titulo);
        },
        failure: function () {
            swal("Atenção", "Erro ao gerar o campeonato.", "error");
        },
        error: function () {
            swal("Atenção", "Erro ao gerar o campeonato.", "error");
        }
    });
}




