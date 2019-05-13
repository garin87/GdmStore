# GdmStore
1. Просмотрите метод SortProducsByParameters в ProductService начало строка 248. (Severity	Code	Description	Project	File	Line	 Suppression State Error	CS1662	Cannot convert lambda expression to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type	GdmStore	C:\Projects\GdmStore\GdmStore\Services\ProductService.cs	259	Active
) В этом методе я хочу в вначале выбирать необходимые диаметры по параметрам, после чего отсортировать их по product.amount. 

2. Подскажите идею, как правильно решить проблему того, что когда я удаляю продукт удаляется и  ифн. о нем в order,  а надо чтобы инф о продукте в заказе сохронялись и после удаления продукта.    
