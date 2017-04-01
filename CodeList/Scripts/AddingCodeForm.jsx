var AddingCodeForm = React.createClass({

    handleNewRecord: function (e) {
        this.refs.txtName.value = "";
        this.refs.txtDescription.value = "";
        this.refs.txtCode.value = "";

        this.props.onNewRecord();
    },

    handleSubmit: function (event) {
        //e.preventDefault();
        var txtName = this.refs.txtName.value;
        var txtDescription = this.refs.txtDescription.value;
        var txtCode = this.refs.txtCode.value;


        var dataToSubmit = { Name: txtName, Description: txtDescription, Program: txtCode }
        var component = this;

        jQuery.ajax({
            type: "POST",
            url: "/Code/Save",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(dataToSubmit),
            success: function (data) {
                component.handleNewRecord();

            },
            failure: function (errMsg) {
                alert(errMsg);
            }

        });
    },
    render: function () {
        return(
            <form >
                <table >
                    <tbody>
                    <tr>
                        <td>
                            Name:
                        </td>
                        <td>
                            <input type="text" ref="txtName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
            Description:
        </td>
        <td>
            <input type="text" ref="txtDescription" />
        </td>
    </tr>
    <tr>
        <td>
            Code:
        </td>
        <td>
            <textarea ref="txtCode" className="codeArea"></textarea>
        </td>
    </tr>
    </tbody>
</table>
<input type="button"  value="Save Code" onClick={this.handleSubmit} />
</form>
        )
    }
});

//====================================================================================================
