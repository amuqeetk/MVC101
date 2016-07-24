﻿function AuthorFormViewModel(author) {
    var self = this;

    self.saveCompleted = ko.observable(false);
    self.sending = ko.observable(false);

    self.isCreating = author.id == 0;

    self.author = {
        id:author.id,
        firstName: ko.observable(author.firstName),
        lastName: ko.observable(author.lastName),
        biography: ko.observable(author.biography),
        //__RequestVerificationToken:ko.observable(),
    };

    self.validateAndSave = function (form) {
        if (!$(form).valid()) {
            return false;
        }
        self.author.__RequestVerificationToken = form[0].value;
        self.sending(true);

        $.ajax({
            url: (self.isCreating)?'Create':'Edit',
            type: "post",
            contentType: 'application/x-www-form-urlencoded',
            data: ko.toJS(self.author),
        })
        .success(self.successfulSave)
        .error(self.errorSave)
        .complete(function () {
            self.sending(false)
        });
    };

    self.successfulSave = function () {
        self.saveCompleted(true);
        $(".body-content").prepend(
            '<div class="alert alert-success"><strong>Success</strong> The new Author has been saved.</div>');
        setTimeout(function () {
            if (self.isCreating) {
                location.href = './';
            }
            else {
                location.href = '../';
            }
        }, 1000);
    };

    self.errorSave = function () {
        $(".body-content").prepend(
            '<div class="alert alert-danger"><strong>Error!</strong>There was an error saving the author.</div>');
    };
}