

async function listarTipoDeSala(): Promise<void> {
    await $('#Grilla_TipoDeSala').data('kendoGrid')?.dataSource.read();
}


function onErrorTipo(e: Event): any {
    console.log('Error', e);
}

function parametrosGrillaTipoDeSala(): any {
    return {
        descripcion: $('#Grilla_TipoDeSala').data("kendoGid")
    };
}