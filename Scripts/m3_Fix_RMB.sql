UPDATE patients, cdprovince SET patients.province = [cdprovince].[ProvName]
WHERE (((patients.province)=[cdprovince].[ProvCode]));