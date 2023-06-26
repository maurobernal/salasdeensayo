/* eslint-disable @typescript-eslint/indent */

async function listarSalas(): Promise<void> {
    await $('#Grilla_Salas').data('kendoGrid')?.dataSource.read();
}

function parametrosGrilla(): any {
    return {
        tipodesalaid: $('#lbx_tiposdesala')!.data('kendoDropDownList')!.value(),
    };
}
