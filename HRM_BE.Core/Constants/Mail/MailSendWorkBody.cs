using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Constants.Mail
{
    public static class MailSendWorkBody
    {
        public static string CreateBodyHTMLFormat(string ExecutorName, string RepoterName, string WorkName, string UrlWork, string DueDate, string ProjectName)
        {
            return
                $"""
                    <!DOCTYPE html>
                <html>
                <head>
                  <title>Email Notification</title>
                </head>
                <body style="font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f4;">
                  <table align="center" width="600" style="background-color: #ffffff; margin: 20px auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);">
                    <tr>
                      <td style="text-align: left; padding-bottom: 20px;">
                        <p style="font-size: 16px; margin: 0;">
                          Thân gửi <strong>{ExecutorName}</strong>
                        </p>
                        <p style="color: #888; font-size: 14px; margin: 5px 0 15px;">
                          {RepoterName} vừa giao công việc cho bạn
                        </p>
                        <a href="{UrlWork}" style="display: inline-block; padding: 10px 20px; color: #ffffff; background-color: #007bff; text-decoration: none; border-radius: 5px; font-size: 14px;">Xem chi tiết</a>
                      </td>
                    </tr>
                    <tr>
                      <td style="background-color: #f9f9f9; padding: 15px; border-radius: 8px;">
                        <p style="font-size: 14px; color: #333; margin: 0;"><strong>Tên công việc:</strong>{WorkName}</p>
                        <p style="font-size: 14px; color: #333; margin: 5px 0;"><strong>Thuộc dự án:</strong> <span style="color: #28a745;">{ProjectName}</span></p>
                        <p style="font-size: 14px; color: #333; margin: 5px 0;"><strong>Hạn hoàn thành:</strong> {DueDate}</p>
                      </td>
                    </tr>
                    <tr>
                      <td style="padding-top: 20px; text-align: center; color: #888; font-size: 12px;">
                        Email này được gửi tự động từ ứng dụng Công việc. Vui lòng không trả lời mail này.
                      </td>
                    </tr>
                  </table>
                </body>
                </html>
                
                """;
        }
        public static string UpdateBodyHTMLFormat(string ExecutorName, string ReporterName, string WorkName, string UrlWork, string DueDate, string ProjectName)
        {
            return
                $"""
            <!DOCTYPE html>
        <html>
        <head>
          <title>Cập nhật công việc</title>
        </head>
        <body style="font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f4;">
          <table align="center" width="600" style="background-color: #ffffff; margin: 20px auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);">
            <tr>
              <td style="text-align: left; padding-bottom: 20px;">
                <p style="font-size: 16px; margin: 0;">
                  Thân gửi <strong>{ExecutorName}</strong>,
                </p>
                <p style="color: #888; font-size: 14px; margin: 5px 0 15px;">
                  {ReporterName} đã cập nhật công việc liên quan đến bạn.
                </p>
                <a href="{UrlWork}" style="display: inline-block; padding: 10px 20px; color: #ffffff; background-color: #007bff; text-decoration: none; border-radius: 5px; font-size: 14px;">Xem chi tiết công việc</a>
              </td>
            </tr>
            <tr>
              <td style="background-color: #f9f9f9; padding: 15px; border-radius: 8px;">
                <p style="font-size: 14px; color: #333; margin: 0;"><strong>Tên công việc:</strong> {WorkName}</p>
                <p style="font-size: 14px; color: #333; margin: 5px 0;"><strong>Thuộc dự án:</strong> <span style="color: #28a745;">{ProjectName}</span></p>
                <p style="font-size: 14px; color: #333; margin: 5px 0;"><strong>Hạn hoàn thành:</strong> {DueDate}</p>
              </td>
            </tr>
            <tr>
              <td style="padding-top: 20px; text-align: center; color: #888; font-size: 12px;">
                Email này được gửi tự động từ hệ thống quản lý công việc. Vui lòng không trả lời email này.
              </td>
            </tr>
          </table>
        </body>
        </html>
        """;
        }

    }
}
