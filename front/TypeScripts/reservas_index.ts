/* eslint-disable @typescript-eslint/indent */
function parametros(): any {
    return {
        tipodesalaid: $('#lbx_tiposdesala').data("kendoDropDownList")?.value()
    };
}

async function listar(): Promise<void> {
    await $('#salaid').data('kendoDropDownList')?.dataSource.read();
}