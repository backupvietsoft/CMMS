﻿DELETE FROM LIC_MENU WHERE ID IN(

SELECT TOP 1 ID FROM LIC_MENU WHERE MENU_ID = N'ΞΠήͤΔΆΠͬΖΊΔ͠͠͠͞'
)