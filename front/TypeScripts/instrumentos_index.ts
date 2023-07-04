function error_handler(e: any): any {
    if (e != null) {
        console.log('Error', e);
            if (e.errors) {
            var message = "Errores:\n";
            $.each(e.errors, function (key, value) {
                        message += value + "\n";
            });
            
            alert(message);
        }
    }
}


