SELECT processed_service_record.id, processed_service_record.status, patients.ohip, processed_service_record.service_code, processed_service_record.service_date, processed_service_record.AmountPaid, processed_service_record.ExplanatoryCode, processed_service_record.Submitted_Fee INTO temp_reconc
FROM processed_service_record INNER JOIN patients ON processed_service_record.patient_id = patients.id
WHERE (((processed_service_record.status)=1 Or (processed_service_record.status)=2 Or (processed_service_record.status)=4));