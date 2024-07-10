//Scripts para as telas do menu do usuário
function hideAllExcept(current) {
    $("#usuario-menu-tela-adicionar, #usuario-menu-tela-editar, #usuario-menu-tela-listar, #usuario-menu-tela-excluir").not(current).hide();
}

$("#usuario-menu-btn-adicionar").click(function() {
    hideAllExcept("#usuario-menu-tela-adicionar");
    $("#usuario-menu-tela-adicionar").fadeToggle(500);
});

$("#usuario-menu-btn-editar").click(function() {
    hideAllExcept("#usuario-menu-tela-editar");
    $("#usuario-menu-tela-editar").fadeToggle(500);
});

$("#usuario-menu-btn-listar").click(function() {
    hideAllExcept("#usuario-menu-tela-listar");
    $("#usuario-menu-tela-listar").fadeToggle(500);
});

$("#usuario-menu-btn-excluir").click(function() {
    hideAllExcept("#usuario-menu-tela-excluir");
    $("#usuario-menu-tela-excluir").fadeToggle(500);
});

//Script para a tela de edição

$(document).ready(function() {
    $('#form-usuario-editar-btn').click(function() {
        $('#form-usuario-editar').submit();
    });
});

