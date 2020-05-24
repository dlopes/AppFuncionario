var idFuncionario = 0;
var nomeFuncionario = "";
var PorcentagemTotal = 200;


$(document).ready(function () {
    $(".PessoaId").click(function () {
        idFuncionario = $(this).attr("pessoa-id");
        nomeFuncionario = $(this).attr("pessoa-nome");
        $("#add-modal-nome").html(nomeFuncionario);
       
    });
});

function AdiconarReal(valor) {

    let inputVal = $("#id-valor-" + idFuncionario).val();
    let somaVal = somar(inputVal, valor)

    $("#id-valor-" + idFuncionario).val(somaVal);
   
    let porcentagem = (somaVal * 100) / PorcentagemTotal;

    $("#progress_bar_" + idFuncionario).css("width", porcentagem + "%");
    let valExt = "R$ " + currencyFormat(somaVal);
    $("#progress_bar_" + idFuncionario).html(valExt);
    $("#valorPessoa_" + idFuncionario).html("Você já adicionou" + valExt);
    $("#header-qtd-adicioanado-" + idFuncionario).addClass("qtd-adicioanado-prenchida");
   
}

function somar(val1, val2) {

    return parseInt(val1) + parseInt(val2);

}

function currencyFormat(num) {
    return num.toFixed(2).replace(".", ",").replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
}
