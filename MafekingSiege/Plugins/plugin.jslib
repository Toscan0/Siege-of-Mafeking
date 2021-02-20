var plugin = {
    Hello : function()
    {
        window.alert("Hello, world!");
    },
};
mergeInto(LibraryManager.library, plugin);