function rebindOnEdit(e) {
    if (e.type == "update") {
        this.read();
    }
}