/* eslint-disable @typescript-eslint/indent */
function parametros(): any {
    return {
        tipodesalaid: $('#TipoDeSalaId').data("kendoDropDownList")?.value()
    };
}

async function listar(): Promise<void> {
    await $('#SalaDeEnsayoId').data('kendoDropDownList')?.dataSource.read();
}
