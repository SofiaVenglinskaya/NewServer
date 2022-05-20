import 'dart:convert';

List<MessagesModel> messageModelFromJson(String str) => List<MessagesModel>.from(json.decode(str).map((x) => MessagesModel.fromJson(x)));

String messageModelToJson(List<MessagesModel> data) => json.encode(List<dynamic>.from(data.map((x) => x.toJson())));

class MessagesModel {
    MessagesModel({
        required this.id,
        required this.text,
        required this.senderUserId,
        required this.recieverUserId,
        required this.dateOfSending,
    });

    int id;
    String text;
    int senderUserId;
    int recieverUserId;
    DateTime dateOfSending;

    factory MessagesModel.fromJson(Map<String, dynamic> json) => MessagesModel(
        id: json["Id  "],
        text: json["Text  "],
        senderUserId: json["SenderUserId "],
        recieverUserId: json["RecieverUserId "],
        dateOfSending: json["DateOfSending "],
    );

    Map<String, dynamic> toJson() => {
        "Id  ": id,
        "Text  ": text,
        "SenderUserId ": senderUserId,
        "RecieverUserId ": recieverUserId,
        "DateOfSending ": dateOfSending,
    };
}