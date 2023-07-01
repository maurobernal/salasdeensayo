/* eslint-disable @typescript-eslint/indent */

async function listarSalas(): Promise<void> {
    await $('#Grilla_Salas').data('kendoGrid')?.dataSource.read();
}
function onError(e: Event): any {
    console.log('Error', e);
}


