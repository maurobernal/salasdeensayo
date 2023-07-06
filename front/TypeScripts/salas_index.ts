/* eslint-disable @typescript-eslint/indent */

async function listarSalas(): Promise<void> {
    await $('#Grilla_Salas').data('kendoGrid')?.dataSource.read();
}
function onError(e: Event): any {
    console.log('Error', e);
}

function parametrosGrilla(): any {
    return {
        descripcion: $('#Grilla_Salas').data("kendoGid")
    };
}


function parametrosGrillas(): any {
    return {
        tipodesalaid: $('#lbx_tiposdesala').data("kendoDropDownList")?.value()
    };
}