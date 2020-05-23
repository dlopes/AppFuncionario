var idFuncinario = 0;
var PorcentagemTotal = 200;


$(document).ready(function () {
    $(".PessoaId").click(function () {
        idFuncinario = $(this).attr("pessoa-id");
       
    });
});

function AdiconarReal(valor) {

    let inputVal = $("#id-valor-" + idFuncinario).val();
    let somaVal = somar(inputVal, valor)

    $("#id-valor-" + idFuncinario).val(somaVal);
   
    let porcentagem = (somaVal * 100) / PorcentagemTotal;

    $("#progress_bar_" + idFuncinario).css("width", porcentagem + "%");
    let valExt = "R$ " + currencyFormat(somaVal);
    $("#progress_bar_" + idFuncinario).html(valExt);
    $("#valorPessoa_" + idFuncinario).html("Você já adicionou" + valExt);
    $("#header-qtd-adicioanado-" + idFuncinario).addClass("qtd-adicioanado-prenchida");
   
}

function somar(val1, val2) {

    return parseInt(val1) + parseInt(val2);

}

function currencyFormat(num) {
    return num.toFixed(2).replace(".", ",").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
}
