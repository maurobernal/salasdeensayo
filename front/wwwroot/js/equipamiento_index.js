"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function listarEquipamientos() {
    var _a;
    return __awaiter(this, void 0, void 0, function* () {
        yield ((_a = $('#Grilla_Equipamiento').data('kendoGrid')) === null || _a === void 0 ? void 0 : _a.dataSource.read());
    });
}
function onErrorEquipamiento(e) {
    console.log('Error', e);
}
function parametrosGrillaEquipamiento() {
    var _a;
    return {
        idsala: (_a = $('#lbx_salasdeensayo').data("kendoDropDownList")) === null || _a === void 0 ? void 0 : _a.value()
    };
}
