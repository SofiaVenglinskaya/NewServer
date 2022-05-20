import 'dart:convert';

List<InvitationModel> userInvitationsModelFromJson(String str) => List<InvitationModel>.from(json.decode(str).map((x) => InvitationModel.fromJson(x)));

String userInvitationsModelToJson(List<InvitationModel> data) => json.encode(List<dynamic>.from(data.map((x) => x.toJson())));

class InvitationModel {
    InvitationModel({
        required this.senderUserId,
        required this.accepterUserId,
    });

    int senderUserId;
    int accepterUserId;

    factory InvitationModel.fromJson(Map<String, dynamic> json) => InvitationModel(
        senderUserId: json["SenderUserId"],
        accepterUserId: json["AccepterUserId"],
    );

    Map<String, dynamic> toJson() => {
        "SenderUserId": senderUserId,
        "AccepterUserId": accepterUserId,
    };
}