UPDATE processed_service_record, temp_paid SET processed_service_record.status = 3
WHERE (((temp_paid.id)=[processed_service_record].[id]));