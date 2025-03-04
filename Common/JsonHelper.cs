﻿using Common.JsonConverter;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Common
{
    public class JsonHelper
    {


        /// <summary>
        /// 通过 Key 获取 Value
        /// </summary>
        /// <returns></returns>
        public static string? GetValueByKey(string json, string key)
        {
            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                var jsonElement = doc.RootElement.Clone();

                return jsonElement.GetProperty(key).GetString();
            }
            catch
            {
                return null;
            }
        }



        /// <summary> 
        /// 对象 转 Json
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string ObjectToJson(object obj)
        {
            JsonSerializerOptions options = new();
            options.Converters.Add(new DateTimeConverter());
            options.Converters.Add(new DateTimeOffsetConverter());
            options.Converters.Add(new LongConverter());

            options.Converters.Add(new NullableConverter<DateTime>());
            options.Converters.Add(new NullableConverter<DateTimeOffset>());
            options.Converters.Add(new NullableConverter<long>());
            options.Converters.Add(new NullableConverter<int>());
            options.Converters.Add(new NullableConverter<double>());
            options.Converters.Add(new NullableConverter<decimal>());
            options.Converters.Add(new NullableConverter<float>());
            options.Converters.Add(new NullableConverter<Guid>());
            options.Converters.Add(new NullableConverter<bool>());

            //关闭默认转义
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            //启用驼峰格式
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            //关闭缩进设置
            options.WriteIndented = false;

            return JsonSerializer.Serialize(obj, options);
        }




        /// <summary> 
        /// Json 转 对象
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        public static T JsonToObject<T>(string json)
        {
            JsonSerializerOptions options = new();
            options.Converters.Add(new DateTimeConverter());
            options.Converters.Add(new DateTimeOffsetConverter());
            options.Converters.Add(new LongConverter());

            options.Converters.Add(new NullableConverter<DateTime>());
            options.Converters.Add(new NullableConverter<DateTimeOffset>());
            options.Converters.Add(new NullableConverter<long>());
            options.Converters.Add(new NullableConverter<int>());
            options.Converters.Add(new NullableConverter<double>());
            options.Converters.Add(new NullableConverter<decimal>());
            options.Converters.Add(new NullableConverter<float>());
            options.Converters.Add(new NullableConverter<Guid>());
            options.Converters.Add(new NullableConverter<bool>());

            //启用大小写不敏感
            options.PropertyNameCaseInsensitive = true;

            return JsonSerializer.Deserialize<T>(json, options)!;
        }




        /// <summary>
        /// 没有 Key 的 Json 转 List<JToken>
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static JsonNode? JsonToArrayList(string json)
        {
            var jsonNode = JsonNode.Parse(json);

            return jsonNode;
        }


    }
}
