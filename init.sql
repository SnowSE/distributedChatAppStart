create table message (
  username text,
  message text,
  file_name text,
  image_api_id number

);

create table image_file_name_lookup(
  file_name text,
  generated_file_name text
);