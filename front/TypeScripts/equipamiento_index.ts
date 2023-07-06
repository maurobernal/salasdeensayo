async function listarEquipamientos(): Promise<void> {
    await $('#Grilla_Equipamiento').data('kendoGrid')?.dataSource.read();
}
function onErrorEquipamiento(e: Event): any {
    console.log('Error', e);
}

function parametrosGrillaEquipamiento(): any {
    return {
        idsala: $('#lbx_salasdeensayo').data("kendoDropDownList")?.value()
    };
}