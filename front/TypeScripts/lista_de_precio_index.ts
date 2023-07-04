async function listarListaPrecio(): Promise<void> {
    await $('#Grilla_ListaDePrecio').data('kendoGrid')?.dataSource.read();
}
function parametrosGrillaListaPrecio(): any {
    return {
        idSala: $('#lbx_tiposdesala').data('kendoDropDownList')?.value()
    };
}
