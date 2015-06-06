private["_table"];
_table = _this select 0;
private["_itemId"];
_itemId = _this select 1;

"Arma2NET" callExtension format["TAP item|select|%1|%2", _table, _itemId];
