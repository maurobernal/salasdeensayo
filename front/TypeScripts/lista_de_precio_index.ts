async function listarListaPrecio(): Promise<void> {
    await $('#Grilla_ListaDePrecio').data('kendoGrid')?.dataSource.read();
}
function parametrosGrillaListaPrecio(): any {
    return {
        idsala: $('#lbx_tiposdesala').data('kendoDropDownList')?.value()
    };
}
