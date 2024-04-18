using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Do_an_nhom
{
    internal class SerializationHelper
    {
        public static void Serialize<T>(List<T> list, string filePath)
        {
            try
            {
                //Tạo 1 list để lưu trữ tạm thông tin khi kiểm tra ds trong vong lặp
                List<T> newItemsToAdd = new List<T>();

                // Kiểm tra nếu tệp đã tồn tại
                if (File.Exists(filePath))
                {
                    // Đọc dữ liệu từ tệp đã tồn tại
                    string newJson = File.ReadAllText(filePath);
                    List<T> deserializedList = JsonSerializer.Deserialize<List<T>>(newJson);

                    // Kiểm tra xem thông tin mới vừa nhập đã tồn tại trong danh sách hiện có hay không
                    foreach (T newItem in list)
                    {
                        bool exists = deserializedList.Contains(newItem);
                        if (exists)
                        {
                            Console.WriteLine($"Thông tin mới đã tồn tại trong tập tin: {newItem}");
                        }
                        else
                        {
                            // Thêm thông tin mới vào danh sách đã đọc được (nếu chưa tồn tại)
                            newItemsToAdd.Add(newItem);
                        }
                    }


                    deserializedList.AddRange(newItemsToAdd);
                    string json = JsonSerializer.Serialize(deserializedList, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filePath, json);
                    Console.WriteLine("Serialization successful.");
                }
                else
                {
                    // Nếu tệp không tồn tại, tạo một tệp mới và ghi danh sách vào đó
                    string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filePath, json);
                    Console.WriteLine("New file created and serialization successful.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serialization failed: {ex.Message}");
            }
        }

        public static void Deserialize<T>(List<T> list, string filePath)
        {
            try
            {
                string newJson = File.ReadAllText(filePath);
                List<T> deserializedList = JsonSerializer.Deserialize<List<T>>(newJson);
                Console.WriteLine("Deserialization successful.");
                foreach (T item in deserializedList)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialization failed: {ex.Message}");
            }
        }
    }
}
