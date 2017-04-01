
var CodeItem = React.createClass({
    itemDeleted: function (event) {
        this.props.onItemDeleted();
    },

    handleDelete: function (event) {
        var objData = { recordID: this.props.RecordId };
        var component = this;

        jQuery.ajax({
            type: "POST",
            url: "/Code/Delete",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(objData),
            success: function (data) {
                component.itemDeleted();
            },
            failure: function (errMsg) {
                alert(errMsg);
            }
        });

    },

    render: function() {
        return (
          <div className="code_item" >
            {this.props.Name}
            <br />
            Description:   {this.props.Description}<br />
            <pre>{this.props.Program}</pre>
            <br/>
            Created By:    {this.props.CreatedBy}<br />
            <input type="button"  onClick={this.handleDelete} value="Delete"/>
            <hr />
          </div>
      );
    }
});
